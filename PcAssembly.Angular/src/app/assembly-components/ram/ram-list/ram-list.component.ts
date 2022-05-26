import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute, Router } from '@angular/router';
import { merge } from 'rxjs';
import { ConfirmDialogComponent } from 'src/app/confirm-dialog/confirm-dialog.component';
import { ConfirmDialogModule } from 'src/app/confirm-dialog/confirm-dialog.module';
import { Ram } from 'src/app/interface/pc-components/ram.model';
import { Motherboard } from 'src/app/interface/pc-components/motherboard.model';
import { AuthenticationService } from 'src/app/shared/services/authentication.service';
import { Location } from '@angular/common';
import { RamTableService } from 'src/app/shared/services/ram-table.service';
import { Filter } from 'src/app/_infrastructure/models/Filter';
import { FilterLogicalOperators } from 'src/app/_infrastructure/models/FilterLogicalOperators';
import { PagedResult } from 'src/app/_infrastructure/models/PagedResult';
import { PaginatedRequest } from 'src/app/_infrastructure/models/PaginatedRequest';
import { RequestFilters } from 'src/app/_infrastructure/models/RequestFilters';
import { TableColumn } from 'src/app/_infrastructure/models/TableColumn';
@Component({
  selector: 'app-ram-list',
  templateUrl: './ram-list.component.html',
  styleUrls: ['./ram-list.component.css']
})
export class RamListComponent implements AfterViewInit, OnInit {

  pagedRams: PagedResult<Ram>;
  isLoading = true;
  noItems = false;

  tableColumns: TableColumn[] = [
    { name: 'imageUrl', index: 'imageUrl', displayName: 'Image' },
    { name: 'model', index: 'model', displayName: 'Model', useInSearch: true },
    { name: 'company', index: 'company', displayName: 'Company', useInSearch: true },
    { name: 'price', index: 'price', displayName: 'Price' },
    { name: 'ramType', index: 'ramType', displayName: 'RamType', useInSearch: true },
    { name: 'ramSize', index: 'ramSize', displayName: 'RamSize', useInSearch: true  },
    { name: 'count', index: 'count', displayName: 'Count', useInSearch: true  },
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

  public dataSource = new MatTableDataSource<Ram>();

  constructor(
    private route: ActivatedRoute,
    private ramService: RamTableService,
    private authService: AuthenticationService,
    private formBuilder: FormBuilder,
    public dialog: MatDialog,
    public snackBar: MatSnackBar,
    private router: Router,
    private location: Location
    ) {
        this.displayedColumns = this.tableColumns.map(column => column.name);
        this.filterForm = this.formBuilder.group({
        model: [''],
        company: [''],
        ramType: [''],
        ramSize: [''],
        count: ['']
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
      if(this.select)
        this.filterRamsFromForm();
      else
        this.loadRamsFromApi();
      
      this.sort.sortChange.subscribe(() => this.paginator.pageIndex = 0);
  
      merge(this.sort.sortChange, this.paginator.page).subscribe(() => {
        this.loadRamsFromApi();
      });
    }

    loadRamsFromApi() {
      const paginatedRequest = new PaginatedRequest(this.paginator, this.sort, this.requestFilters);
      this.ramService.getDataPaged(paginatedRequest)
        .subscribe((pagedRams: PagedResult<Ram>) => {
          this.noItems = false;
          this.isLoading = false;
          this.pagedRams = pagedRams;
          if(pagedRams.total == 0){
            this.noItems = true;
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
            this.ramService.delete(id).subscribe(
              () => {
                this.loadRamsFromApi();
    
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
      this.filterFirst();
      this.createFiltersFromSearchInput();
      this.loadRamsFromApi();
    }

    resetGrid() {
      this.requestFilters = {filters: [], logicalOperator: FilterLogicalOperators.And};
      this.loadRamsFromApi();
    }
  
    filterRamsFromForm() {
      this.filterFirst();
      this.createFiltersFromForm();
      this.loadRamsFromApi();
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

    filterFirst(){
      if(localStorage.getItem('motherboard')!==null){
       let motherboard =  JSON.parse(localStorage.getItem('motherboard')) as Motherboard;
       this.filterForm.controls['ramType'].setValue(motherboard.ramType);
      }
    }

    selectRam(id: string): void{
      this.ramService.getById(id).subscribe((ramObj: Ram) => {
        localStorage.setItem('ram', JSON.stringify(ramObj));
        this.location.back();
      });
     
    }

}
