import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReflectionService } from '../../services/reflection.service';

@Component({
  selector: 'app-reflection',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './reflection.component.html',
  styleUrls: ['./reflection.component.css']
})
export class ReflectionComponent {
  importers: string[] = [];
  isLoading = false;
  error: string | null = null;

  constructor(private reflectionService: ReflectionService) {}

  loadImporters() {
    this.isLoading = true;
    this.error = null;

    this.reflectionService.getImporters().subscribe({
      next: (data) => {
        this.importers = data;
        this.isLoading = false;
      },
      error: (err) => {
        console.error(err);
        this.error = 'Error al cargar los importers.';
        this.isLoading = false;
      }
    });
  }
}