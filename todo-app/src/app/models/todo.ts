export interface Todo {
  id: number;
  title: string;
  isDone: boolean;
}

export interface ApiResponse<T> {
  success: boolean;
  data: T;
  message: string;
  error: string | null;
}