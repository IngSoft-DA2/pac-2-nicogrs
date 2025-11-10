import { Routes } from '@angular/router';
import { ReflectionComponent } from './pages/reflection/reflection.component';
import { ConsignaComponent } from './shared/components/consigna/consigna.component';
import { ReflectionGuard } from './guards/reflection.guard';


export const routes: Routes = [
    { path: '', component: ConsignaComponent},
    { path: 'reflection', component: ReflectionComponent, canActivate: [ReflectionGuard] }
];
