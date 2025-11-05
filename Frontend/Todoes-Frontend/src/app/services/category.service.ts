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

  private colorSchemes: Record<string, { background: string; text: string, selected: string}> = {
    Work: { background: '#dbeafe', text: '#1e40af', selected:'#1e3a8a'}, // blue
    Personal: { background: '#fecaca', text: '#f87171', selected:'#7f1d1d' }, // red
    Shopping: { background: '#fef9c3', text: '#854d0e', selected:'#713f12' }, // yellow
    Health: { background: '#dcfce7', text: '#166534', selected:'#14532d' }, // green
    Finance: { background: '#e0e7ff', text: '#3730a3', selected:'#312e81' }, // indigo
    Study: { background: '#f3e8ff', text: '#6b21a8', selected:'#6b21a8' }, // purple
    Home: { background: '#fce7f3', text: '#9d174d', selected:'#9d174d' }, // pink
    Errands: { background: '#f3f4f6', text: '#1f2937', selected:'#374151' }, // gray
    Travel: { background: '#fee2e2', text: '#991b1b' , selected:'#721616ff'}, // redish
    Miscellaneous: { background: '#fef9c3', text: '#854d0e', selected:'#713f12'}, // yellow again
  };

  constructor() {}
  getCategoryId(id: number): Category | undefined {
    return this.categories.find((c) => c.id === id);
  }

  getCategoryColors(name: string): { background: string; text: string } {
    return this.colorSchemes[name] || { background: '#f3f4f6', text: '#1f2937' }; // default gray
  }
}
