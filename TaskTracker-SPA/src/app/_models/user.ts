import { Task } from './task';

export interface User {
  id: number;
  userName: string;
  firstName: string;
  lastName: string;
  created: Date;
  city: string;
  streetAddress: string;
  phoneNumber: string;
  tasks?: Task[];
  roles?: string[];
}
