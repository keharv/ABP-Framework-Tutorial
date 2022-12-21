import { NgModule } from '@angular/core';

import { SharedModule } from '../shared/shared.module';

import { LibraryRoutingModule } from './library-routing.module';
import { LibraryComponent } from './library.component';
import { NgbDatepickerModule } from '@ng-bootstrap/ng-bootstrap';


@NgModule({
  declarations: [
    LibraryComponent
  ],
  imports: [
    SharedModule,
    LibraryRoutingModule,
    NgbDatepickerModule
  ]
})
export class LibraryModule { }
