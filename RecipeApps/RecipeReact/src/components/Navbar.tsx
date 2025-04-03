import { useEffect, useState } from "react";
import { CuisineNavbar } from "./CuisineNavbar";
import "./navbar.css";
import { ICuisine } from "../Interfaces";
import { fetchCuisine } from "../DataUtil";

interface Props {
    cuisineClick: (num: number) => void;
    showRecipesClick: (isVisible: boolean) => void;
}

function Navbar({ cuisineClick, showRecipesClick }: Props) {
    const [cuisines, setCuisines] = useState<ICuisine[]>([]);
    useEffect(() => {
        (async () => {
            setCuisines(await fetchCuisine());
        })();
    }, []);

    return (
        <>
            <nav className="navbar navbar-expand-lg navbar-light bg-light">
                <a className="navbar-brand" href="#">
                    <img src="/images/Hearty Hearth.jpg" alt="Logo" className="d-inline-block rounded-3 p-1 navbar-logo" />
                </a>
                <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent">
                    <span className="navbar-toggler-icon"></span>
                </button>

                <div className="collapse navbar-collapse" id="navbarSupportedContent">
                    <ul className="navbar-nav mr-auto">
                        <li className="nav-item">
                            <button className="nav-link" id="navbarDropdown" role="button" data-bs-toggle="collapse" data-bs-target="#subnavCollapse">
                                Recipes <span className="dropdown-toggle ps-1"></span>
                            </button>
                        </li>
                        <li className="nav-item active"><a className="nav-link" href="#">Meals</a></li>
                        <li className="nav-item"><a className="nav-link" href="#">Cookbooks</a></li>
                    </ul>
                </div>
            </nav>
            <div className="collapse" id="subnavCollapse">
                <div className="row">
                    <div className="col-12">
                        <h1 className="text-center">Select a Cuisine</h1>
                    </div>
                </div>
                <div className="row">
                    {cuisines.map((c, i) => (
                        <CuisineNavbar cuisine={c} key={i} cuisineClick={cuisineClick} showRecipesClick={showRecipesClick} />
                    ))}
                </div>
            </div>
        </>
    );
}

export default Navbar;
