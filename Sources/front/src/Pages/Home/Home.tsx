import { useGetUser } from "../../Hooks/User/useGetUser";

export default function Home() {
  const { data: user, isLoading } = useGetUser();

  if (isLoading) return <p>Loading user...</p>;
  if (!user) return <p>No user data found.</p>;

  return (
    <div>
      <h1>Welcome, {user.name} 👋</h1>
    </div>
  );
}
