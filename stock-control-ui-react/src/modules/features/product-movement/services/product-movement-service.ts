import ProductMovementModel from "../models/product-movement-model";

export async function postProductMovement(productMovement: ProductMovementModel) {
  if (!productMovement || !(productMovement instanceof ProductMovementModel)) {
    throw new Error('Invalid product movement data');
  }

  const response = await fetch('/api/product-movement', {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json',
    },
    body: JSON.stringify(productMovement),
  });

  if (!response.ok) {
    throw new Error('Failed to post product movement');
  }

  return response.json();
}