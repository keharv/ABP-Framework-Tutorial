import type { AuditedEntityDto, EntityDto } from '@abp/ng.core';
import type { BookType } from './book-type.enum';

export interface AuthorLookupDto extends EntityDto<string> {
  name?: string;
}

export interface BookDto extends AuditedEntityDto<string> {
  authorId?: string;
  libraryId?: string;
  authorName?: string;
  libraryName?: string;
  name?: string;
  type: BookType;
  publishDate?: string;
  price: number;
}

export interface CreateUpdateBookDto {
  name: string;
  type: BookType;
  publishDate: string;
  price: number;
  authorId?: string;
  libraryId?: string;
}

export interface LibraryLookupDto extends EntityDto<string> {
  name?: string;
}
