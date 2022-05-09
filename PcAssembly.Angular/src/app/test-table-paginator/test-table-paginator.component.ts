import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { TablePage } from './table-page';

@Component({
  selector: 'app-test-table-paginator',
  templateUrl: './test-table-paginator.component.html',
  styleUrls: ['./test-table-paginator.component.css']
})
export class TestTablePaginatorComponent{

  @Input() page: TablePage;
  @Output() pageChange = new EventEmitter<TablePage>();

  @Input() total: number;



  private ChangePageIndex(index: number){
    this.page = {...this.page, index};
    // this.page.index = index;
    this.pageChange.emit(this.page);
  }

  goToFirstPage(){
    this.ChangePageIndex(0);
  }

  next(): void{
    this.ChangePageIndex(this.page.index + 1);
  }

  previous(): void{
    this.ChangePageIndex(this.page.index - 1);
  }

}
