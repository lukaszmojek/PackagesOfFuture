import * as jwt from 'jwt-decode'

export interface DecodedToken extends jwt.JwtPayload {
  role: string;
  id: number;
}