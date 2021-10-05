import { Component, OnInit } from '@angular/core';
import { Product } from '../product';
import { ProductService } from '../product.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {

  products !: Product[];
  constructor(private service : ProductService) { }

  ngOnInit(): void {
    this.service.GetProducts().subscribe(data => {
      this.products = data;
      console.log(this.products);
      
    }
    );
  }

  deleteproduct(id:number)
  {
    this.service.DeleteProduct(id).subscribe();
  }
}