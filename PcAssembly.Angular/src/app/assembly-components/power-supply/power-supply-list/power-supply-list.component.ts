import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute } from '@angular/router';
import { merge } from 'rxjs';
import { ConfirmDialogComponent } from 'src/app/confirm-dialog/confirm-dialog.component';
import { PowerSupply } from 'src/app/interface/pc-components/power-supply.model';
import { AuthenticationService } from 'src/app/shared/services/authentication.service';
import { PowerSupplyTableService } from 'src/app/shared/services/power-supply-table.service';
import { Filter } from 'src/app/_infrastructure/models/Filter';
import { FilterLogicalOperators } from 'src/app/_infrastructure/models/FilterLogicalOperators';
import { PagedResult } from 'src/app/_infrastructure/models/PagedResult';
import { PaginatedRequest } from 'src/app/_infrastructure/models/PaginatedRequest';
import { RequestFilters } from 'src/app/_infrastructure/models/RequestFilters';
import { TableColumn } from 'src/app/_infrastructure/models/TableColumn';
@Component({
  selector: 'app-power-supply-list',
  templateUrl: './power-supply-list.component.html',
  styleUrls: ['./power-supply-list.component.css']
})
export class PowerSupplyListComponent implements AfterViewInit, OnInit {

  pagedPowerSupplys: PagedResult<PowerSupply>;

  tableColumns: TableColumn[] = [
    { name: 'imageUrl', index: 'imageUrl', displayName: 'Image' },
    { name: 'model', index: 'model', displayName: 'Model', useInSearch: true },
    { name: 'company', index: 'company', displayName: 'Company', useInSearch: true },
    { name: 'price', index: 'price', displayName: 'Price' },
    { name: 'power', index: 'Power', displayName: 'Power' },
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

  public dataSource = new MatTableDataSource<PowerSupply>();

  constructor(
    private powerSupplyService: PowerSupplyTableService,
    private authService: AuthenticationService,
    private formBuilder: FormBuilder,
    public dialog: MatDialog,
    public snackBar: MatSnackBar,
    private route: ActivatedRoute,
    ) {
        this.displayedColumns = this.tableColumns.map(column => column.name);
        this.filterForm = this.formBuilder.group({
        model: [''],
        company: [''],
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
      this.loadPowerSupplysFromApi();
      this.sort.sortChange.subscribe(() => this.paginator.pageIndex = 0);
  
      merge(this.sort.sortChange, this.paginator.page).subscribe(() => {
        this.loadPowerSupplysFromApi();
      });
    }

    loadPowerSupplysFromApi() {
      const paginatedRequest = new PaginatedRequest(this.paginator, this.sort, this.requestFilters);
      this.powerSupplyService.getDataPaged(paginatedRequest)
        .subscribe((pagedPowerSupplys: PagedResult<PowerSupply>) => {
          this.pagedPowerSupplys = pagedPowerSupplys;
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
            this.powerSupplyService.delete(id).subscribe(
              () => {
                this.loadPowerSupplysFromApi();
    
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
      this.loadPowerSupplysFromApi();
    }

    resetGrid() {
      this.requestFilters = {filters: [], logicalOperator: FilterLogicalOperators.And};
      this.loadPowerSupplysFromApi();
    }
  
    filterPowerSupplysFromForm() {
      this.createFiltersFromForm();
      this.loadPowerSupplysFromApi();
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

    selectPowerSupply(id: string): void{
      this.powerSupplyService.getById(id).subscribe((powerSupplyObj: PowerSupply) => {
        localStorage.setItem('power-supply', JSON.stringify(powerSupplyObj));
      })
    }

}
