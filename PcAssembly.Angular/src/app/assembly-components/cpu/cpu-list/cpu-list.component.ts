import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute, Router } from '@angular/router';
import { merge } from 'rxjs';
import { Location } from '@angular/common';
import { ConfirmDialogComponent } from 'src/app/confirm-dialog/confirm-dialog.component';
import { ConfirmDialogModule } from 'src/app/confirm-dialog/confirm-dialog.module';
import { CPU } from 'src/app/interface/pc-components/cpu.model';
import { Motherboard } from 'src/app/interface/pc-components/motherboard.model';
import { AuthenticationService } from 'src/app/shared/services/authentication.service';
import { CpuTableService } from 'src/app/shared/services/cpu-table.service';
import { Filter } from 'src/app/_infrastructure/models/Filter';
import { FilterLogicalOperators } from 'src/app/_infrastructure/models/FilterLogicalOperators';
import { PagedResult } from 'src/app/_infrastructure/models/PagedResult';
import { PaginatedRequest } from 'src/app/_infrastructure/models/PaginatedRequest';
import { RequestFilters } from 'src/app/_infrastructure/models/RequestFilters';
import { TableColumn } from 'src/app/_infrastructure/models/TableColumn';
@Component({
  selector: 'app-cpu-list',
  templateUrl: './cpu-list.component.html',
  styleUrls: ['./cpu-list.component.css']
})
export class CpuListComponent implements AfterViewInit, OnInit {

  pagedCpus: PagedResult<CPU>;
  isLoading = true;

  tableColumns: TableColumn[] = [
    { name: 'imageUrl', index: 'imageUrl', displayName: 'Image' },
    { name: 'model', index: 'model', displayName: 'Model', useInSearch: true },
    { name: 'company', index: 'company', displayName: 'Company', useInSearch: true },
    { name: 'price', index: 'price', displayName: 'Price' },
    { name: 'socket', index: 'socket', displayName: 'Socket', useInSearch: true },
    { name: 'family', index: 'family', displayName: 'Family', useInSearch: true },
    { name: 'generation', index: 'generation', displayName: 'Generation', useInSearch: true },
    { name: 'cores', index: 'cores', displayName: 'Cores'},
    { name: 'threads', index: 'threads', displayName: 'Threads' },
    { name: 'frequency', index: 'frequency', displayName: 'Frequency' },
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

  public dataSource = new MatTableDataSource<CPU>();

  constructor(
    private route: ActivatedRoute,
    private cpuService: CpuTableService,
    private authService: AuthenticationService,
    private formBuilder: FormBuilder,
    public dialog: MatDialog,
    public snackBar: MatSnackBar,
    private router: Router,
    private location: Location,
    ) {
        this.displayedColumns = this.tableColumns.map(column => column.name);
        this.filterForm = this.formBuilder.group({
        model: [''],
        company: [''],
        socket: [''],
        family: [''],
        generation: ['']
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
        this.filterFirst();
      else
        this.loadCpusFromApi();
      
      this.sort.sortChange.subscribe(() => this.paginator.pageIndex = 0);
  
      merge(this.sort.sortChange, this.paginator.page).subscribe(() => {
        this.loadCpusFromApi();
      });
    }
    noItems: boolean = false;

    loadCpusFromApi() {
      const paginatedRequest = new PaginatedRequest(this.paginator, this.sort, this.requestFilters);
      this.cpuService.getDataPaged(paginatedRequest)
        .subscribe((pagedCpus: PagedResult<CPU>) => {
          this.noItems = false;
          this.isLoading = false;
          this.pagedCpus = pagedCpus;
          if(pagedCpus.total == 0){
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
            this.cpuService.delete(id).subscribe(
              () => {
                this.loadCpusFromApi();
    
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
      this.loadCpusFromApi();
    }

    resetGrid() {
      this.requestFilters = {filters: [], logicalOperator: FilterLogicalOperators.And};
      this.loadCpusFromApi();
    }
  
    filterCpusFromForm() {
      this.createFiltersFromForm();
      this.loadCpusFromApi();
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
       this.filterForm.controls['socket'].setValue(motherboard.socket);
      };
      this.filterCpusFromForm();
    }

    selectCpu(id: string): void{
      this.cpuService.getById(id).subscribe((cpuObj: CPU) => {
        localStorage.setItem('cpu', JSON.stringify(cpuObj));
        this.location.back();
      })
      
    }

}
