// import { useForm } from "react-hook-form";
import "./AddMeal.scss";

// type TMeal = {
//    type: 'Breakfast' | 'Lunch' | 'Dinner';
//    name: string;
//    quantity: number;
//    unit: 'g' | 'ml' | 'piece'
//    calories: number;
//    proteins: number;
//    carbs: number;
//    fat: number;
// }

export const AddMeal = () => {
  // const methods = useForm<TMeal[]>({
  //     defaultValues: []
  // });

  return (
    <div className="add-meal">
      <h2>Add a Meal</h2>
      <form className="add-meal__form">
        <div className="add-meal__form__field">
          <label>Type</label>
          <select value={""}>
            <option>Breakfast</option>
            <option>Lunch</option>
            <option>Dinner</option>
            <option>Snack</option>
          </select>
        </div>
        <div className="add-meal__form__field">
          <label>Name</label>
          <input type="text" />
        </div>
        <div className="add-meal__form__field">
          <label>Quantity</label>
          <>
            <input type="number" />
            <select value={""}>
              <option>g</option>
              <option>ml</option>
              <option>piece</option>
            </select>
          </>
        </div>
        <div className="add-meal__form__field">
          <label>Calories</label>
          <input type="number" />
        </div>
        <div className="add-meal__form__field">
          <label>Proteins</label>
          <input type="number" />
        </div>
        <div className="add-meal__form__field">
          <label>Carbs</label>
          <input type="number" />
        </div>
        <div className="add-meal__form__field">
          <label>Fat</label>
          <input type="number" />
        </div>
      </form>
    </div>
  );
};
