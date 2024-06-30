import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { CommonModule } from '@angular/common';
import { MenuCategoryComponent } from './menu-category/menu-category.component';
import { PageTitleComponent } from './page-title/page-title.component';
import { AdminComponent } from './admin/admin.component';
import { CategoriesComponent } from './categories/categories.component';


@NgModule({
  declarations: [
    MenuCategoryComponent,
    PageTitleComponent,
    AdminComponent,
    CategoriesComponent,
  ],
  imports: [
    CommonModule,
    RouterModule
  ],
  exports: [
    MenuCategoryComponent,
    PageTitleComponent
  ]
})
export class ComponentsModule
{ }
