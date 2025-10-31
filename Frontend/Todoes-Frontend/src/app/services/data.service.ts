import { computed, Injectable, signal } from '@angular/core';
import { Category, Todo } from '../model/todo';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  todoList = signal<Todo[]>([])
  
  filter = signal<Category | null>(null);

  displayedTodos = computed(() => {
    if (!this.filter()) return this.todoList()
    return this.todoList().filter(t => t.category.id === this.filter()!.id)
  })

  constructor() { }
}
