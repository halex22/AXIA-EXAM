import { Injectable } from '@angular/core';
import { Category } from '../model/todo';

@Injectable({
  providedIn: 'root',
})
export class CategoryService {
  
    categories: Category[] = [
      { name: 'Work', id: 1 },
      { name: 'Personal', id: 2 },
      { name: 'Shopping', id: 3 },
      { name: 'Health', id: 4 },
      { name: 'Finance', id: 5 },
      { name: 'Study', id: 6 },
      { name: 'Home', id: 7 },
      { name: 'Errands', id: 8 },
      { name: 'Travel', id: 9 },
      { name: 'Miscellaneous', id: 10 },
    ];

  constructor() {}
  getCategoryId(id: number): Category | undefined {
    return this.categories.find((c) => c.id === id);
  }
}
