import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { Product } from '../product';
import { ProductService } from '../product.service';

@Component({
  selector: 'app-add-products',
  templateUrl: './add-products.component.html',
  styleUrls: ['./add-products.component.css']
})
export class AddProductsComponent implements OnInit {

  constructor(private formBuilder: FormBuilder, private service: ProductService) { }
  addproductform : any;
  products !: Product;

  ngOnInit(): void {

    this.addproductform = this.formBuilder.group({
      id : new FormControl(),
      name : new FormControl(),
      description : new FormControl(),
      price : new FormControl(),
      quantity : new FormControl()
    })
  }

  get id()
  {
    return this.addproductform.get("id");
  }
  get name()
  {
    return this.addproductform.get("name");
  }
  get description()
  {
    return this.addproductform.get("description");
  }
  get price()
  {
    return this.addproductform.get("price");
  }
  get quantity()
  {
    return this.addproductform.get("quantity");
  }

  submitForm()
  {
    this.service.AddProducts(this.addproductform.value).subscribe();
  }

}
