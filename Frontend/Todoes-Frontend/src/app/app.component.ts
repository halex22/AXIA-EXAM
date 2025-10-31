import { Component } from '@angular/core';
import { TodoCategoriesComponent } from './components/todo-categories/todo-categories.component';
import { TodoListComponent } from './components/todo-list/todo-list.component';


@Component({
  selector: 'app-root',
  standalone: true,
  imports: [TodoCategoriesComponent, TodoListComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
}
