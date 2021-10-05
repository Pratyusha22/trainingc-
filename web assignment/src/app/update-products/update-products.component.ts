import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { Product } from '../product';
import { ProductService } from '../product.service';
import {ActivatedRoute, Router} from '@angular/router';

@Component({
  selector: 'app-update-products',
  templateUrl: './update-products.component.html',
  styleUrls: ['./update-products.component.css']
})
export class UpdateProductsComponent implements OnInit {

  constructor(private router:ActivatedRoute, private service: ProductService,
    private route:Router) { }

  updateproductform =new FormGroup({
    id : new FormControl(''),
    name : new FormControl(''),
    description : new FormControl(''),
    price : new FormControl(''),
    quantity : new FormControl('')
  });
  product !: Product;

  ngOnInit(): void {
    this.service.GetProductById(this.router.snapshot.params['productid']).subscribe((data)=>   
    this.updateproductform=new FormGroup({
      id:new FormControl(data["id"]),
      name:new FormControl(data["name"]),
      description:new FormControl(data["description"]),
      price:new FormControl(data["price"]),
      quantity:new FormControl(data["quantity"])
    })
    )

  }

  submitForm()
  {
    this.service.UpdateProduct(
      this.router.snapshot.params['productid'], this.updateproductform.value).subscribe();
      this.route.navigateByUrl("/Home");
  }
  
}
