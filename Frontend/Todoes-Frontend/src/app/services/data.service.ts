import { computed, Injectable, signal } from '@angular/core';
import { Category, Todo } from '../model/todo';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  todoList = signal<Todo[]>([])
  
  filter = signal<Category | null>(null);

  private readonly baseUrl = 'https://localhost:7065/api/'

  displayedTodos = computed(() => {
    if (!this.filter()) return this.todoList()
    return this.todoList().filter(t => t.category.id === this.filter()!.id)
  })

  constructor() { 
    this.loadTodos()
  }

  loadTodos() {
    return fetch(`${this.baseUrl}Todoes`).then(res => res.json())
    .then(data => this.todoList.set(data))
  }
}
