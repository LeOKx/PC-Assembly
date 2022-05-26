import { Component, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup, FormBuilder } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute, Router } from '@angular/router';
import { merge } from 'rxjs';
import { ConfirmDialogComponent } from 'src/app/confirm-dialog/confirm-dialog.component';
import { Assembly } from 'src/app/interface/pc-components/assembly/assembly.model';
import { Motherboard } from 'src/app/interface/pc-components/motherboard.model';
import { AuthenticationService } from 'src/app/shared/services/authentication.service';
import { Filter } from 'src/app/_infrastructure/models/Filter';
import { FilterLogicalOperators } from 'src/app/_infrastructure/models/FilterLogicalOperators';
import { PagedResult } from 'src/app/_infrastructure/models/PagedResult';
import { PaginatedRequest } from 'src/app/_infrastructure/models/PaginatedRequest';
import { RequestFilters } from 'src/app/_infrastructure/models/RequestFilters';
import { TableColumn } from 'src/app/_infrastructure/models/TableColumn';
import { AssemblyService } from 'src/app/shared/services/assembly.service';
import { UserInfo } from 'src/app/interface/user/userInfo copy';

@Component({
  selector: 'app-assembly-list',
  templateUrl: './assembly-list.component.html',
  styleUrls: ['./assembly-list.component.css']
})
export class AssemblyListComponent implements OnInit {
  isLoading = true;
  noItems = false;
  usersInfo: UserInfo[]=[];

  pagedAssemblies: PagedResult<Assembly>;

  tableColumns: TableColumn[] = [
    { name: 'imageUrl', index: 'imageUrl', displayName: 'Image' },
    { name: 'name', index: 'name', displayName: 'name', useInSearch: true },
    { name: 'totalPrice', index: 'totalPrice', displayName: 'Price'},
    { name: 'rating', index: 'rating', displayName: 'Rating'},
    { name: 'userId', index: 'userId', displayName: 'UserId'},
    { name: 'createDate', index: 'createDate', displayName: 'CreateDate'},
    { name: 'id', index: 'id', displayName: 'Id' },
  ];


  displayedColumns: string[];

  searchInput = new FormControl('');
  filterForm: FormGroup;
  public isAdmin: boolean;
  public select: string = '';
  requestFilters: RequestFilters;


  @ViewChild(MatPaginator, {static: false}) paginator: MatPaginator;
  @ViewChild(MatSort, { static: false}) sort: MatSort;

  public dataSource = new MatTableDataSource<Assembly>();

  constructor(
    private route: ActivatedRoute,
    private assemblyService: AssemblyService,
    private authService: AuthenticationService,
    private formBuilder: FormBuilder,
    public dialog: MatDialog,
    public snackBar: MatSnackBar,
    private router: Router,
    ) {
        this.displayedColumns = this.tableColumns.map(column => column.name);
        this.filterForm = this.formBuilder.group({
        name: [''],
      });
     }
     ngOnInit(): void {
     
     let selectParam: string;
    this.route.params.subscribe(params =>{
      selectParam = params['select'];
      if(selectParam !== 'select'){
        this.isAdmin = this.authService.isUserAdmin();
      }else {
        this.select = selectParam;
      }
      });
    }

    ngAfterViewInit() {
        this.loadAssembliesFromApi();
      
      this.sort.sortChange.subscribe(() => this.paginator.pageIndex = 0);
  
      merge(this.sort.sortChange, this.paginator.page).subscribe(() => {
        this.loadAssembliesFromApi();
      });
    }

    loadAssembliesFromApi() {
      const paginatedRequest = new PaginatedRequest(this.paginator, this.sort, this.requestFilters);
      this.assemblyService.getDataPaged(paginatedRequest)
        .subscribe((pagedAssemblies: PagedResult<Assembly>) => {
          this.noItems = false;
          this.isLoading = false;
          this.pagedAssemblies = pagedAssemblies as PagedResult<Assembly>;
          if(pagedAssemblies.total == 0){
            this.noItems = true;
          }
          var assemblies = pagedAssemblies.items as Assembly[]
          for(let assembly of assemblies){
            this.getInfo(assembly.userId);
          }
          
        });
    }

    openDialogForDeleting(id: string) {
      if(this.authService.isUserAdmin()){
        const dialogRef = this.dialog.open(ConfirmDialogComponent, {
          data: { title: 'Dialog', message: 'Are you sure to delete this item?' }
        });
        dialogRef.disableClose = true;
    
        dialogRef.afterClosed().subscribe(result => {
          if (result === dialogRef.componentInstance.ACTION_CONFIRM) {
            this.assemblyService.delete(id).subscribe(
              () => {
                this.loadAssembliesFromApi();
    
                this.snackBar.open('The item has been deleted successfully.', 'Close', {
                  duration: 1500
                });
              }
            );
          }
        });
      }
    }

    applySearch() {
      this.createFiltersFromSearchInput();
      this.loadAssembliesFromApi();
    }

    resetGrid() {
      this.requestFilters = {filters: [], logicalOperator: FilterLogicalOperators.And};
      this.loadAssembliesFromApi();
    }
  
    filterAssembliesFromForm() {
      this.createFiltersFromForm();
      this.loadAssembliesFromApi();
    }

    private createFiltersFromForm() {
      if (this.filterForm.value) {
        const filters: Filter[] = [];
  
        Object.keys(this.filterForm.controls).forEach(key => {
          const controlValue = this.filterForm.controls[key].value;
          if (controlValue) {
            const foundTableColumn = this.tableColumns.find(tableColumn => tableColumn.name === key);
            const filter: Filter = { path : foundTableColumn.index, value : controlValue };
            filters.push(filter);
          }
        });
  
        this.requestFilters = {
          logicalOperator: FilterLogicalOperators.And,
          filters
        };
      }
    }

    private createFiltersFromSearchInput() {
      const filterValue = this.searchInput.value.trim();
      if (filterValue) {
        const filters: Filter[] = [];
        this.tableColumns.forEach(column => {
          if (column.useInSearch) {
            const filter: Filter = { path : column.index, value : filterValue };
            filters.push(filter);
          }
        });
        this.requestFilters = {
          logicalOperator: FilterLogicalOperators.Or,
          filters
        };
      } else {
        this.resetGrid();
      }
    }

    usersMass: [{userIdmas: string, userInfo: UserInfo}] = [{userIdmas: null, userInfo: null}];
    getInfo(userId: string){
      let _username: UserInfo;
      this.authService.getUsername(userId)
      .subscribe((userInfo: UserInfo) =>{
        this.usersMass.push({userIdmas: userId, userInfo: userInfo})
      });
    }

    getUsername(userId: string):string{
      let userMass = this.usersMass.find(x => x.userIdmas == userId)
      let _username = userMass?.userInfo?.userName;
      return _username;
    }


}
