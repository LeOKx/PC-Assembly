import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { CPU, CPU_DATA } from '../cpu/interface/cpu.model';
import { TablePage } from '../test-table-paginator/table-page';
import { TestTablePaginatorComponent } from '../test-table-paginator/test-table-paginator.component';

@Component({
  selector: 'app-test-component',
  templateUrl: './test-component.component.html',
  styleUrls: ['./test-component.component.css']
})
export class TestComponent implements OnInit, AfterViewInit {
  title: string = "Hello World!";
  inputVal: number = 0;
  value: number = 12;
  cpuArr: CPU[];
  pageData: CPU[];
  pageModel: TablePage = new TablePage(1);

  @ViewChild(TestTablePaginatorComponent) paginator: TestTablePaginatorComponent;


  toggle = false;
  constructor() {
   }
  ngAfterViewInit(): void {
    this.paginator.pageChange.subscribe(pageFromChild => {
      this.setPageData(pageFromChild)
    });
  }
   setAnotherNumber(val:number): void{
      this.value = val;  
   }
   onInput(event: any){
     this.value = event.target.value;
   }

  ngOnInit(): void {
    this.cpuArr = CPU_DATA;
    this.setPageData(this.pageModel);
  }

  removeItem(cpu: CPU){
    const index = this.cpuArr.indexOf(cpu);
    this.cpuArr.splice(index, 1);
    if(this.pageModel.index !== 0){
      this.pageModel.index--;
    }
    this.setPageData(this.pageModel);
  }

  setPageData(page: TablePage): void{
    this.pageData = this.cpuArr.slice(page.index * page.size, (page.index+1) * page.size)
  }

}
