import {Routes} from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AuthGuard } from './_guards/auth.guard';
import { AdminPanelComponent } from './admin/admin-panel/admin-panel.component';
import { UsersComponent } from './users/users.component';
import { UsersResolver } from './_resolvers/users.resolver';
import { TasksResolver } from './_resolvers/tasks.resolver';

export const appRoutes: Routes = [
    {path: '', component: HomeComponent},
    {
        path: '',
        runGuardsAndResolvers: 'always',
        canActivate: [AuthGuard],
        children: [
            {path: 'users', component: UsersComponent, resolve: {users: UsersResolver, tasks: TasksResolver}},
            {path: 'admin', component: AdminPanelComponent, data: {roles: ['Admin']}},
        ]
    },
    {path: '**', redirectTo: '', pathMatch: 'full'},
];
