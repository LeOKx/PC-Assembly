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
import { CPU } from 'src/app/interface/pc-components/cpu.model';
import { Motherboard } from 'src/app/interface/pc-components/motherboard.model';
import { Ram } from 'src/app/interface/pc-components/ram.model';
import { AuthenticationService } from 'src/app/shared/services/authentication.service';
import { MotherboardTableService } from 'src/app/shared/services/motherboard-table.service';
import { Filter } from 'src/app/_infrastructure/models/Filter';
import { FilterLogicalOperators } from 'src/app/_infrastructure/models/FilterLogicalOperators';
import { PagedResult } from 'src/app/_infrastructure/models/PagedResult';
import { PaginatedRequest } from 'src/app/_infrastructure/models/PaginatedRequest';
import { RequestFilters } from 'src/app/_infrastructure/models/RequestFilters';
import { TableColumn } from 'src/app/_infrastructure/models/TableColumn';
import { Location } from '@angular/common';
@Component({
  selector: 'app-motherboard-list',
  templateUrl: './motherboard-list.component.html',
  styleUrls: ['./motherboard-list.component.css']
})
export class MotherboardListComponent implements AfterViewInit, OnInit {

  pagedMotherboards: PagedResult<Motherboard>;
  isLoading = true;
  noItems = false;

  tableColumns: TableColumn[] = [
    { name: 'imageUrl', index: 'imageUrl', displayName: 'Image' },
    { name: 'model', index: 'model', displayName: 'Model', useInSearch: true },
    { name: 'company', index: 'company', displayName: 'Company', useInSearch: true },
    { name: 'price', index: 'price', displayName: 'Price' },
    { name: 'socket', index: 'socket', displayName: 'Socket', useInSearch: true },
    { name: 'chipset', index: 'chipset', displayName: 'Chipset', useInSearch: true  },
    { name: 'formFactor', index: 'formFactor', displayName: 'FormFactor', useInSearch: true  },
    { name: 'ramType', index: 'ramType', displayName: 'RamType', useInSearch: true  },
    { name: 'ramSlots', index: 'ramSlots', displayName: 'RamSlots' },
    { name: 'powerConsumption', index: 'powerConsumption', displayName: 'PowerConsumption' },
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

  public dataSource = new MatTableDataSource<Motherboard>();

  constructor(
    private motherboardService: MotherboardTableService,
    private authService: AuthenticationService,
    private formBuilder: FormBuilder,
    public dialog: MatDialog,
    public snackBar: MatSnackBar,
    private route: ActivatedRoute,
    private router: Router,
    private location: Location,
    ) {
        this.displayedColumns = this.tableColumns.map(column => column.name);
        this.filterForm = this.formBuilder.group({
        model: [''],
        company: [''],
        socket: [''],
        chipset: [''],
        formFactor: [''],
        ramType: [''],
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
      if(this.select == 'select')
        this.filterMotherboardsFromForm();
      else
      this.loadMotherboardsFromApi();

      this.sort.sortChange.subscribe(() => this.paginator.pageIndex = 0);
  
      merge(this.sort.sortChange, this.paginator.page).subscribe(() => {
        this.loadMotherboardsFromApi();
      });
    }

    loadMotherboardsFromApi() {
      const paginatedRequest = new PaginatedRequest(this.paginator, this.sort, this.requestFilters);
      this.motherboardService.getDataPaged(paginatedRequest)
        .subscribe((pagedMotherboards: PagedResult<Motherboard>) => {
          this.noItems = false;
          this.isLoading = false;
          this.pagedMotherboards = pagedMotherboards;
          if(pagedMotherboards.total == 0){
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
            this.motherboardService.delete(id).subscribe(
              () => {
                this.loadMotherboardsFromApi();
    
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
      this.filterFirst();
      this.loadMotherboardsFromApi();
    }

    resetGrid() {
      this.requestFilters = {filters: [], logicalOperator: FilterLogicalOperators.And};
      this.loadMotherboardsFromApi();
    }
  
    filterMotherboardsFromForm() {
      this.filterFirst();
      this.createFiltersFromForm();
      this.loadMotherboardsFromApi();
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

    selectMotherboard(id: string): void{
      this.motherboardService.getById(id).subscribe((motherboardObj: Motherboard) => {
        localStorage.setItem('motherboard', JSON.stringify(motherboardObj));
        this.location.back();
      });
      
    }
    filterFirst(){
      if(localStorage.getItem('cpu')!==null){
       let cpu =  JSON.parse(localStorage.getItem('cpu')) as CPU;
       this.filterForm.controls['socket'].setValue(cpu.socket);
      }
      if(localStorage.getItem('ram')!==null){
        let ram =  JSON.parse(localStorage.getItem('ram')) as Ram;
       this.filterForm.controls['ramType'].setValue(ram.ramType);
      }
    }

}
