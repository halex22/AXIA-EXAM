import { Component, inject } from '@angular/core';
import { CategoryService } from '../../services/category.service';
import { DataService } from '../../services/data.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'ul[categoryList]',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './todo-categories.component.html',
  styleUrl: './todo-categories.component.scss'
})
export class TodoCategoriesComponent {

  catService = inject(CategoryService)
  dataService = inject(DataService)

  clearFilter(){
    this.dataService.filter.set(null)
  }

  setFilter(id: number){
    const cat = this.catService.getCategoryId(id)
    if (!cat) return
    this.dataService.filter.set(cat)
  }

}
