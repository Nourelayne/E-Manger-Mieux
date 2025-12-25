import { Route, Routes } from 'react-router-dom';
import { UserProvider } from './User/UserProvider';
import Home from '../Pages/Home/Home';

const App = () => (
<UserProvider>
  <Routes>
    <Route path="/" element={<Home />} />
  </Routes>
</UserProvider>
)

export default App
