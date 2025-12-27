import { ApiError } from "./ApiError";

export class UnauthenticatedError extends ApiError {
  constructor() {
    super("You are not authenticated", 401);
    this.name = "UnauthenticatedError";
  }
}
