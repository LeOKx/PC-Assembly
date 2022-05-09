import { Component, ContentChild, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { CPU } from '../cpu/interface/cpu.model';
import { TestTablePaginatorComponent } from '../test-table-paginator/test-table-paginator.component';

@Component({
  selector: 'app-test-array',
  templateUrl: './test-array.component.html',
  styleUrls: ['./test-array.component.css']
})
export class TestArrayComponent {

  @Input() cpus!: CPU[];
  @Output() remove = new EventEmitter<CPU>();

  @ContentChild(TestTablePaginatorComponent) paginator: TestTablePaginatorComponent;

  onRemove(cpu: CPU){
    // console.log(cpu);
    this.remove.emit(cpu);
    // if(this.paginator.page.index > 0)
    // this.paginator.previous();
    // this.paginator.goToFirstPage();
  }

}
