import type { CreateUpdateLibraryDto, LibraryDto } from './models';
import { RestService } from '@abp/ng.core';
import type { PagedAndSortedResultRequestDto, PagedResultDto } from '@abp/ng.core';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class LibraryService {
  apiName = 'Default';
  

  create = (input: CreateUpdateLibraryDto) =>
    this.restService.request<any, LibraryDto>({
      method: 'POST',
      url: '/api/app/library',
      body: input,
    },
    { apiName: this.apiName });
  

  delete = (id: string) =>
    this.restService.request<any, void>({
      method: 'DELETE',
      url: `/api/app/library/${id}`,
    },
    { apiName: this.apiName });
  

  get = (id: string) =>
    this.restService.request<any, LibraryDto>({
      method: 'GET',
      url: `/api/app/library/${id}`,
    },
    { apiName: this.apiName });
  

  getList = (input: PagedAndSortedResultRequestDto) =>
    this.restService.request<any, PagedResultDto<LibraryDto>>({
      method: 'GET',
      url: '/api/app/library',
      params: { skipCount: input.skipCount, maxResultCount: input.maxResultCount, sorting: input.sorting },
    },
    { apiName: this.apiName });
  

  update = (id: string, input: CreateUpdateLibraryDto) =>
    this.restService.request<any, LibraryDto>({
      method: 'PUT',
      url: `/api/app/library/${id}`,
      body: input,
    },
    { apiName: this.apiName });

  constructor(private restService: RestService) {}
}
