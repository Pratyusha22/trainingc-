import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductListComponent } from './product-list/product-list.component';
import { UpdateProductsComponent } from './update-products/update-products.component';

const routes: Routes = [
  {path:'Home', component: ProductListComponent},
  {path: 'update/:productid', component: UpdateProductsComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
