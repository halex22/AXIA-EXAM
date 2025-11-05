import { Component, inject } from '@angular/core';
import { TodoCategoriesComponent } from './components/todo-categories/todo-categories.component';
import { TodoListComponent } from './components/todo-list/todo-list.component';
import { LoadingComponent } from './components/shared/loading/loading.component';
import { DataService } from './services/data.service';
import { TodoCreateComponent } from './components/todo-create/todo-create.component';


@Component({
  selector: 'app-root',
  standalone: true,
  imports: [TodoCategoriesComponent, TodoListComponent, LoadingComponent, TodoCreateComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  dataService = inject(DataService)
}
