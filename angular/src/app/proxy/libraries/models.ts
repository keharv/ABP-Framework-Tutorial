import type { AuditedEntityDto } from '@abp/ng.core';

export interface CreateUpdateLibraryDto {
  name: string;
  address: string;
  builtDate: string;
}

export interface LibraryDto extends AuditedEntityDto<string> {
  name?: string;
  builtDate?: string;
  address?: string;
}
