import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { HomeComponent } from './pages/home/home.component';
import { AboutMeComponent } from './pages/about-me/about-me.component';
import { ContactComponent } from './pages/contact/contact.component';
import { MainLayoutComponent } from './layout/main-layout/main-layout.component';
import { AdminLayoutComponent } from './layout/admin-layout/admin-layout.component';
import { CategoriesComponent } from './components/categories/categories.component';

const routes: Routes = [
{
  path:"",
  component:MainLayoutComponent,
  children:[
    {
      path:"",
      component:HomeComponent
    },
    {
      path:"hakkimda",
      component:AboutMeComponent
    },
    {
      path:"iletisim",
      component:ContactComponent
    }
  ]
},
{
  path:"Admin",
  component:AdminLayoutComponent,
  children:[
    {
      path:"",
      component:CategoriesComponent
    }
  ]
}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
