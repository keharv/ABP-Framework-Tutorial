import { Component, OnInit } from '@angular/core';
import { ListService, PagedResultDto } from '@abp/ng.core';
import { LibraryService, LibraryDto } from '@proxy/libraries';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { NgbDateNativeAdapter, NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { ConfirmationService, Confirmation } from '@abp/ng.theme.shared';

@Component({
  selector: 'app-library',
  templateUrl: './library.component.html',
  styleUrls: ['./library.component.scss'],
  providers: [ListService, { provide: NgbDateAdapter, useClass: NgbDateNativeAdapter }],
})
export class LibraryComponent implements OnInit {
  library = { items: [], totalCount: 0 } as PagedResultDto<LibraryDto>;

  isModalOpen = false;

  form: FormGroup;

  selectedLibrary = {} as LibraryDto;

  constructor(
    public readonly list: ListService,
    private libraryService: LibraryService,
    private fb: FormBuilder,
    private confirmation: ConfirmationService
  ) {}

  ngOnInit(): void {
    const libraryStreamCreator = (query) => this.libraryService.getList(query);

    this.list.hookToQuery(libraryStreamCreator).subscribe((response) => {
      this.library = response;
    });
  }

  createLibrary() {
    this.selectedLibrary = {} as LibraryDto;
    this.buildForm();
    this.isModalOpen = true;
  }

  editLibrary(id: string) {
    this.libraryService.get(id).subscribe((library) => {
      this.selectedLibrary = library;
      this.buildForm();
      this.isModalOpen = true;
    });
  }

  buildForm() {
    this.form = this.fb.group({
      name: [this.selectedLibrary.name || '', Validators.required],
      address: [this.selectedLibrary.address || '', Validators.required],
      builtDate: [
        this.selectedLibrary.builtDate ? new Date(this.selectedLibrary.builtDate) : null,
        Validators.required,
      ],
    });
  }

  save() {
    if (this.form.invalid) {
      return;
    }

    if (this.selectedLibrary.id) {
      this.libraryService
        .update(this.selectedLibrary.id, this.form.value)
        .subscribe(() => {
          this.isModalOpen = false;
          this.form.reset();
          this.list.get();
        });
    } else {
      this.libraryService.create(this.form.value).subscribe(() => {
        this.isModalOpen = false;
        this.form.reset();
        this.list.get();
      });
    }
  }

  delete(id: string) {
    this.confirmation.warn('::AreYouSureToDelete', '::AreYouSure')
        .subscribe((status) => {
          if (status === Confirmation.Status.confirm) {
            this.libraryService.delete(id).subscribe(() => this.list.get());
          }
	    });
  }
}