import { Component ,Inject} from '@angular/core';
import { MatDialogModule, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MovieService } from '../../Services/movie.service';
import { AuthServiceService } from '../../Services/auth-service.service';
import { DesignUtilityService } from '../../Services/design-utility.service';
import { DomSanitizer, SafeResourceUrl } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-movie-dialog',
  standalone: true,
  imports: [CommonModule,MatDialogModule],
  templateUrl: './movie-dialog.component.html',
  styleUrl: './movie-dialog.component.css'
})
export class MovieDialogComponent {
  
  
  constructor(@Inject(MAT_DIALOG_DATA) public movie: any, private movieService: MovieService,private svc: AuthServiceService, private du: DesignUtilityService,public sanitizer: DomSanitizer) {}

  email:string = this.svc.getEmail();

  openSnackBar(message: string, action: string) {
    this.du.openSnackBar(message, action)
  }

  sanitizeUrl(url: string): SafeResourceUrl {
    return this.sanitizer.bypassSecurityTrustResourceUrl(url);
  }

  toggleFavorite(movie: any, event: Event): void {
  const temp = this.svc.getToken();
  if (temp == null) {
    this.openSnackBar("Login First!!!!", "ok");
  } else {
    event.stopPropagation();

    const favMovieDetails = {
      "favId": 0,
      "id": movie.movieId,
      "title": movie.title,
      "description": movie.description,
      "image": movie.image,
      "thumbnail": movie.thumbnail,
      "rating": movie.rating,
      "year": movie.year,
      "email": this.email,
      "big_image": movie.bigImage,
      "trailer_embed_link": movie.trailerLink
    };

    if (!movie.favourite) { 
      this.movieService.addToFavMovie(favMovieDetails).subscribe(
        (response) => {
          console.log('Movie added to favorites');
          movie.favourite = true; 
          this.openSnackBar("Added to Favourites", "ok");
        },
        (error) => {
          console.error('Error adding movie to favorites', error);
          this.openSnackBar("Failed to add to Favourites", "ok"); 
        }
      );
    } else {
      this.movieService.removeFavMovie(movie.movieId, this.email).subscribe(
        () => {
          console.log('Movie removed from favorites');
          movie.favourite = false; 
          this.openSnackBar("Removed from Favourites", "ok");
        },
        (error) => {
          console.error('Error removing movie from favorites', error);
          this.openSnackBar("Failed to remove from Favourites", "ok");
        }
      );
    }
  }
}

}
