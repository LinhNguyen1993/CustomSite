import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { AuthService } from './authentication/auth.service';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

@NgModule({
  imports: [
    CommonModule,
    RouterModule
  ],
  exports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule,
    NavMenuComponent    
  ],
  declarations: [
    NavMenuComponent
  ],
  providers: [
    AuthService    
  ]
})
export class CoreModule { }
