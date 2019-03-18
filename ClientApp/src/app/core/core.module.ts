import { AuthService } from './authentication/auth.service';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  imports: [
    CommonModule,    
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  exports: [    
    CommonModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  declarations: [],
  providers: [
    AuthService
  ]
})
export class CoreModule { }
