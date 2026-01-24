import { Route, Routes } from "react-router-dom";
import Home from "../../Pages/Home/Home";
import { AddMeal } from "../../Pages/Form/AddMeal";
import { ProfileForm } from "../../Pages/ProfileForm/ProfileForm";

const Router = () => (
  <Routes>
    <Route path="/" element={<Home />} />
    <Route path="/profile" element={<ProfileForm />} />
    <Route path="/add-meal" element={<AddMeal />} />
  </Routes>
);

export default Router;
