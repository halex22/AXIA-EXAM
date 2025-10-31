export interface Category {
  id: number 
  name: string
}

export interface RawTodo {
  title: string
  category: Category
}

export interface Todo extends RawTodo {
  id: number
  completed: boolean
  createdAt: Date
}
