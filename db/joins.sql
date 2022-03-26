SELECT i.item_name, i.count, i.value, u.unit_name, t.type_name  FROM item i
JOIN unit u
ON u.id = i.unit_id
JOIN item_type t
ON t.id = i.type_id;


SELECT i.item_name, i.count, i.value, u.unit_name, t.type_name  FROM item i
JOIN unit u
ON u.id = i.unit_id
JOIN item_type t
ON t.id = i.type_id
WHERE t.type_name = 'Rezistor';


SELECT i.item_name, i.count, i.value, u.unit_name, t.type_name  FROM item i
JOIN unit u
ON u.id = i.unit_id
JOIN item_type t
ON t.id = i.type_id
ORDER BY i.count;


SELECT sum(i.count) as "total_count" FROM item i
JOIN item_type t
ON t.id = i.type_id
WHERE t.type_name = 'Capacitor';


SELECT i.item_name, i.count, i.value, u.unit_name, t.type_name  FROM item i
JOIN unit u
ON u.id = i.unit_id
JOIN item_type t
ON t.id = i.type_id
WHERE i.count < 50
ORDER BY i.count;
