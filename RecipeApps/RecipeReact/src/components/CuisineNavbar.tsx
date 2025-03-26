import { ICuisine } from "../Interfaces";

interface Props {
    cuisine: ICuisine;
    cuisineClick: (num: number) => void;
}

export function CuisineNavbar({ cuisine, cuisineClick }: Props) {
    return (
        <>
            <div className="col-lg-3">
                <div className="card">
                    <button
                        className="btn btn-outline-success text-white p-1"
                        onClick={() => cuisineClick(cuisine.cuisineId)}
                        data-bs-toggle="collapse"
                        data-bs-target="#subnavCollapse">
                        <img
                            className="card-img"
                            src={`/images/${cuisine.cuisineType.toLowerCase()}-cuisine.jpg`}
                            alt="Card image"
                            style={{ maxWidth: "100%", maxHeight: "100px" }}
                        />
                        <div className="card-img-overlay d-flex justify-content-center align-items-center">
                            <h1 className="card-title align-items-center">
                                {cuisine.cuisineType}
                            </h1>
                        </div>
                    </button>
                </div>
            </div>
        </>
    );
}
