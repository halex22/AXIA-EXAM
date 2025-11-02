import { Component, OnInit } from '@angular/core';
import { inject } from '@angular/core';
import { DataService } from '../../services/data.service';
import { Todo } from '../../model/todo';

@Component({
  selector: 'app-todo-list',
  standalone: true,
  imports: [],
  templateUrl: './todo-list.component.html',
  styleUrl: './todo-list.component.scss'
})
export class TodoListComponent implements OnInit {
  service = inject(DataService)
  todos = this.service.displayedTodos;

  ngOnInit(){
    this.service.loadTodos()
  }



}
