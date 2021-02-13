import { Photo } from './photo';

export interface Member {
  id: number;
  username: string;
  photoUrl: string;
  email?: any;
  age: number;
  knownAs: string;
  created: Date;
  createdUTC: Date;
  lastActive: Date;
  lastActiveUTC: Date;
  gender: string;
  introduction: string;
  lookingFor: string;
  interests: string;
  city: string;
  country: string;
  photos: Photo[];
}
