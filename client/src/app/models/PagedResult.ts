import { Product } from './Product';

export class PagedResult {
  pageNumber: number;
  pageSize: number;
  totalCount: number;
  totalPages: number;
  result: Product[];
}
