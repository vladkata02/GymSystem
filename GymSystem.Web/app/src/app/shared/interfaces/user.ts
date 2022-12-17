export interface IUser {
  userId: number;
  email: string;
  username: string;
  password: string;
  hasActiveSubscription: boolean;
  token: any;
}
