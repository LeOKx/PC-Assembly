import { Component, Inject, OnInit } from '@angular/core';
import {MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';


@Component({
  selector: 'app-confirm-dialog',
  templateUrl: './confirm-dialog.component.html',
  styleUrls: ['./confirm-dialog.component.css']
})
export class ConfirmDialogComponent {

   // dialogActions: string;
   public readonly ACTION_YES: string = "YES";
   public readonly ACTION_NO: string = "NO";
   public readonly ACTION_CANCEL: string = "CANCELED";
   public readonly ACTION_IGNORE: string = "IGNORED";
   public readonly ACTION_OK: string = "OK";
   public readonly ACTION_CLOSE: string = "CLOSED";
   public readonly ACTION_CONFIRM: string = "CONFIRMED";

   constructor( @Inject(MAT_DIALOG_DATA) public data: any, public dialogRef: MatDialogRef<ConfirmDialogComponent>) {


   }

}
