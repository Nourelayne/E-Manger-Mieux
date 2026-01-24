export interface CompleteProfileDto {
  firstName?: string;
  lastName?: string;
  dateOfBirth?: string;
  gender?: "Male" | "Female" | "Other";
  height?: number;
  weight?: number;
}
