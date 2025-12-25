import { useUser } from "../../App/User/UserContext";

export default function Home() {
  const { user, loading, error } = useUser();

  if (loading) return <p>Loading user...</p>;
  if (error) return <p>Error loading user: {error.message}</p>;
  if (!user) return <p>No user data found.</p>;

  return (
    <div>
      <h1>Welcome, {user.name} 👋</h1>
    </div>
  );
}
