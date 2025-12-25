import React, { useState, useEffect, type ReactNode } from "react";
import { type User, UserContext } from "./UserContext";

interface UserProviderProps {
  children: ReactNode;
}

interface BffUserData {
  type: 'name' | 'sid';
  value: string;
}

export const UserProvider: React.FC<UserProviderProps> = ({ children }) => {
  const [user, setUser] = useState<User | null>(null);
  const [loading, setLoading] = useState<boolean>(true);
  const [error, setError] = useState<Error | null>(null);

  useEffect(() => {
    const fetchUser = async () => {
      try {
        setLoading(true);
        const res = await fetch("/bff/user", {
            method: "GET",
            credentials: "include",
            headers: new Headers({
                "Content-Type": "application/json",
                "X-CSRF": "1",
            }),
            cache: "no-store"
        });

        if (!res.ok) {
          throw new Error(`Failed to fetch user: ${res.statusText}`);
        }

        const data: BffUserData[] | undefined = await res.json();
        setUser({ sid: data?.find(d => d.type === "sid")?.value ?? '', name: data?.find(d => d.type === "name")?.value ?? '' });
      } catch (err) {
        console.error("User fetch error:", err);
        setError(err instanceof Error ? err : new Error("Unknown error"));
      } finally {
        setLoading(false);
      }
    };

    fetchUser();
  }, []);

  return (
    <UserContext.Provider value={{ user, loading, error, setUser }}>
      {children}
    </UserContext.Provider>
  );
};
