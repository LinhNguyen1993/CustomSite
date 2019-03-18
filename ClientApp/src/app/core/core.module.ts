import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { AuthService } from './authentication/auth.service';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

@NgModule({
  imports: [
    CommonModule,    
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule
  ],
  exports: [    
    CommonModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule,
    NavMenuComponent,    
  ],
  declarations: [
    NavMenuComponent
  ],
  providers: [
    AuthService
  ]
})
export class CoreModule { }
