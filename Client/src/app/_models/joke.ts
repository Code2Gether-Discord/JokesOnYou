export interface Joke {
  id: number;
  premise: string;
  punchline: string;
  authorId: string;
  uploadDate: string;
  likes: number;
  dislikes: number;
  seen: number;
  tags: string[]
}
