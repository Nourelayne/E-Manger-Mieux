import { createContext, useContext } from "react";

export interface User {
  sid: string;
  name: string;
}

export interface UserContextValue {
  user: User | null;
  loading: boolean;
  error: Error | null;
  setUser: React.Dispatch<React.SetStateAction<User | null>>;
}

export const UserContext = createContext<UserContextValue | null>(null);

export function useUser(): UserContextValue {
  const context = useContext(UserContext);
  if (!context) {
    throw new Error("useUser must be used within a UserProvider");
  }
  return context;
}
