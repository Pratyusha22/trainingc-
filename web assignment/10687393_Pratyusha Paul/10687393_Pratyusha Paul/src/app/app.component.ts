//app.component.ts
import { Component, KeyValueDiffers, ViewChild } from '@angular/core';
import { MatTable } from '@angular/material/table';
import { MatDialog } from '@angular/material/dialog';
import { DialogBoxComponent } from './dialog-box/dialog-box.component';

export interface UsersData {
  name: string;
  id: number;
}

const ELEMENT_DATA: UsersData[] = [
  {id: 1560608756, name: 'Adams Baker'},
  {id: 1560608796, name: 'Clark Davis'},
  {id: 1560608787, name: 'Evans Frank'},
  {id: 1560608805, name: 'Ghosh Hills'}
];
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  displayedColumns: string[] = ['id', 'name', 'action'];
  dataSource = ELEMENT_DATA;

  @ViewChild(MatTable,{static:true}) table!: MatTable<any>;

  constructor(public dialog: MatDialog) {}

  openDialog(action: any,obj:any) {
    obj.action = action;
    const dialogRef = this.dialog.open(DialogBoxComponent, {
      width: '250px',
      data:obj
    });

    dialogRef.afterClosed().subscribe(result => {
      if(result.event == 'Add'){
        this.addRowData(result.data);
      }else if(result.event == 'Update'){
        this.updateRowData(result.data);
      }else if(result.event == 'Delete'){
        this.deleteRowData(result.data);
      }else if(result.event=='Search'){
        this.searchRowData(result.data);
      }
    });
  }

  addRowData(row_obj: { id: number;name: string}){
   
    var d= window.prompt("Enter Phone Number: ");
    this.dataSource.push({
      id:parseInt(d!),
      name:row_obj.name
    });
    this.table.renderRows();
    
  }

 searchRowData(row_obj:{id:number; name:string;}){
   this.dataSource=this.dataSource.filter((value,key)=>{
     if(value.name==row_obj.name){
      alert("Phone Number is " + value.id);
     }
     return true;
     
   });
 }

  updateRowData(row_obj: { id: number; name: string; }){
    this.dataSource = this.dataSource.filter((value,key)=>{
      if(value.id == row_obj.id){
        value.name = row_obj.name;
      }
      return true;
    });
  }
  deleteRowData(row_obj: { id: number; }){
    this.dataSource = this.dataSource.filter((value,key)=>{
      return value.id != row_obj.id;
    });
  }
  }
