import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { RepositoryService } from 'src/app/shared/repository.service';
import { CPU } from '../interface/cpu.model';
import { ServiceResponse } from '../../interface/service-response.model';

@Component({
  selector: 'app-cpu-list',
  templateUrl: './cpu-list.component.html',
  styleUrls: ['./cpu-list.component.css']
})
export class CpuListComponent implements OnInit {

  public response: ServiceResponse;
  public success: boolean;
  public message: string;

  displayedColumns: string[] = [
    'model',
    'company',
    'price',
    'socket',
    'powerConsumtion',
    'family',
    'generation',
    'cores',
    'threads',
    'frequency',
    'details', 'update', 'delete'
  ];
  public dataSource = new MatTableDataSource<CPU>();

  constructor(private repoService: RepositoryService) { }

  ngOnInit(): void {
    this.getAllCpus();
  }

  public getAllCpus = () => {
    this.repoService.getData('api/Cpus')
    .subscribe(res => {
      this.response = res as ServiceResponse;
      this.dataSource.data = this.response.data as CPU[];
      this.success = this.response.success;
      this.message = this.response.message;
    });
  }

  public redirectToDetails = (id: string) => {
    
  }
  public redirectToUpdate = (id: string) => {
    
  }
  public redirectToDelete = (id: string) => {
    
  }

}
